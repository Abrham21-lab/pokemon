const express = require('express');
const router = express.Router();
const {
    createPokemon,
    getPokemons,
    updatePokemon,
    deletePokemon,
} = require('../controllers/pokemonController');

router.post('/pokemons', createPokemon);
router.get('/pokemons', getPokemons);
router.put('/pokemons/:id', updatePokemon);
router.delete('/pokemons/:id', deletePokemon);

module.exports = router;
