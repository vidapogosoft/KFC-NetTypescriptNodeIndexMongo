const mongoose = require('mongoose');

const productosSchema = new mongoose.Schema(
    {
        CodProd: {
            type: String,
            required: true
        },
        Producto: {
            type: String,
            required: true
        },
        Precio: {
            type: String,
            required: true
        }
    }
);

module.exports = mongoose.model('productos', productosSchema)