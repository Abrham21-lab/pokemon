const Pokemon = require('./models/Pokemon');

const createPokemon = async (req, res) => {
    try {
        const pokemon = new Pokemon(req.body);
        const savedPokemon = await pokemon.save();
        res.status(201).json(savedPokemon);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};
const getPokemons = async (req, res) => {
    try {
        const pokemons = await Pokemon.find();
        res.status(200).json(pokemons);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};
const updatePokemon = async (req, res) => {
    try {
        const updatedPokemon = await Pokemon.findByIdAndUpdate(
            req.params.id,
            req.body,
            { new: true }
        );
        res.status(200).json(updatedPokemon);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};
const deletePokemon = async (req, res) => {
    try {
        await Pokemon.findByIdAndDelete(req.params.id);
        res.status(204).send();
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};
