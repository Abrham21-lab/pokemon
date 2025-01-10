const express = require('express');
const connectDB = require('./config/db');
const pokemonRoutes = require('./routes/pokemonRoutes');

const app = express();

// Middleware
app.use(express.json());

// Connect to MongoDB
connectDB();

// API routes
app.use('/api', pokemonRoutes);

// Start server
const PORT = process.env.PORT || 5000;
app.listen(PORT, () => console.log(`Server running on port ${PORT}`));
