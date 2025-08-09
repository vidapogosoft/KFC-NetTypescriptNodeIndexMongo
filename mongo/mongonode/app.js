const express = require('express');
const connectDB = require('./config/db');
require('dotenv').config();

const app = express();

//conectar a mongodb
connectDB();

//parsear json
app.use(express.json());

//definir las rutas
app.use('/api/products', require('./routes/product'));

const PORT = 5000;

app.listen(PORT, () => console.log(`Servidor corriendo en el puerto ${PORT}`));