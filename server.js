// Import the mongoose library for MongoDB interactions
const mongoose = require('mongoose');

// Define the connectDB function to establish a connection to the MongoDB database
const connectDB = async () => {
    try {
        // MongoDB connection URI
        const dbURI = 'mongodb://localhost:27017/your-database-name';

        // Connect to MongoDB using mongoose
        await mongoose.connect(dbURI, {
            useNewUrlParser: true,
            useUnifiedTopology: true,
        });

        console.log('Connected to MongoDB');
    } catch (error) {
        console.error('Error connecting to MongoDB:', error.message);
        process.exit(1); // Exit the process if unable to connect to MongoDB
    }
};

// Call the connectDB function to establish the MongoDB connection
connectDB();