const express = require('express');
const router = express.Router();
const producto = require('../models/productos')

router.get('/', async (req, res) => {
    try {
        const prod = await producto.find();
        res.json(prod);
    } 
    catch (error) {
        res.status(400).send('Error: --' + error.message );
    }

});



module.exports = router;