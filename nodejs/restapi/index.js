const express = require('express');
const app = express();
const port = 3000;

//midddlewares --> parsear JSON cuerpo de los request
app.use(express.json());

//simular uan bd
let libros = [
    {id: 1, titulo: 'Saga de Harry Potter', autor: 'JK Rowling'},
    {id: 2, titulo: 'IT', autor: 'Stephen King'},
    {id: 3, titulo: 'Saga de Harry Potter', autor: 'JK Rowling'},
    {id: 4, titulo: 'Saga de Harry Potter', autor: 'JK Rowling'}
];
let nextid = libros.length > 0 ? Math.max(...libros.map(l=> l.id)) +1 : 1;


//routes de nuestros endpoints
//get all
app.get('/api/libros', (req, res) => {

    res.json(libros);

});

// get filtrado pro parametro
app.get('/api/libros/:id', (req, res) => {

    const id = parseInt(req.params.id);
    const libro = libros.find(l=> l.id === id);
    if(libro)
    {
        res.status(200).json(libro);
    }
    else{
        res.status(404).json({mensaje: 'Libro no encontrado'});
    }

});

//post creacion de registro
app.post('/api/libros/insert', (req, res)=>{

    const nuevolibro = req.body; //viene parseado json

    if(!nuevolibro.titulo || !nuevolibro.autor)
    {
        return res.status(400).json({mensaje: 'Info de titulo y autor son necesarios'});
    }

    nuevolibro.id = nextid++;
    libros.push(nuevolibro);
    res.status(201).json(nuevolibro) //201 created

})

// PUT /api/libros/:id - Actualizar completamente un libro
app.put('/api/libros/upd/:id', (req, res) => {
  const id = parseInt(req.params.id);
  const datosActualizados = req.body;
 
  let libroIndex = libros.findIndex(l => l.id === id);
 
  if (libroIndex !== -1) {
    // Aseguramos que el ID no se cambie si viene en el body
    datosActualizados.id = id;
    libros[libroIndex] = datosActualizados;
    res.json(libros[libroIndex]);
  } else {
    res.status(404).json({ mensaje: 'Libro no encontrado' });
  }
});
 
// DELETE /api/libros/:id - Eliminar un libro
app.delete('/api/libros/del/:id', (req, res) => {
  const id = parseInt(req.params.id);
 
  const initialLength = libros.length;
  libros = libros.filter(l => l.id !== id);
 
  if (libros.length < initialLength) {
    res.status(204).send(); // 204 No Content (éxito, pero sin devolver cuerpo)
  } else {
    res.status(404).json({ mensaje: 'Libro no encontrado' });
  }
});

//verifcacion del apirest ==> pnto de partida
app.get('/', (req,res) => {
    res.send('API REST ONLINE');
});

//inciar el servidor
app.listen(port, () =>{
    console.log(`Servidor de API REST escuchando en http://localhost:${port}`);
});