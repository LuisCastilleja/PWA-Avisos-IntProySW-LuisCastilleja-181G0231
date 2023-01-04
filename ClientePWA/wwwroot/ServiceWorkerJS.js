//self.addEventListener("install", function () {
//    //let shell = [
//    //    "/Pages/Home/login",
//    //    "/Pages/Students/Index", "/Pages/Students/MessageDetailsStudent",
//    //    "/Pages/Teachers/Index", "/Pages/Teachers/MessageDetailsTeacher",
//    //    "/Pages/Teachers/UpdateMessage", "/Pages/Teachers/AddMessage",
//    //    "/Styles/styleAddMessageTeacher.css", "Styles/styleIndexStudent.css",
//    //    "/Styles/styleIndexTeacher.css", "Styles/styleLogin.css",
//    //    "/Styles/styleMessageDetailsStudent.css", "Styles/styleMessageDetailsTeacher.css",
//    //    "/Styles/styleUpdateMessageTeacher.css",
//    //    "/Images/hojaAzul.png", "Images/hojaBlanca.png", "Images/notaAmarilla.png", "Images/notaAmarillaGrande.png",
//    //    "/Images/papelArrugadoCafe.png", "Images/papelCafe.png", "Images/papelVerde.png", "Images/pedazoPapelCafe.png",
//    //    "/Images/ pedazoPapelVerde.png",
//    //    "/",
//    //    "/manifest.json",
//    //];
//    //let cache = await caches.open("cacheAPI");
//    ////Actualizamos el contenido del cache con lo que tiene result
//    //await cache.addAll(shell);
//    if (indexedDB) {
//        let db = indexedDB.open("mensajesDb", 1);
//        db.onupgradeneeded = function () {
//            db.result.createObjectStore("peticiones", { keyPath: "id", autoIncrement: true });
//            db.result.createObjectStore("cambios", { keyPath: "fecha" });
//        };
//    }
//});

//self.addEventListener("activate", function () {
//    setInterval(function () {
//        if (navigator.onLine) {
//            forwardSavedRequests();
//        }
//    }, 20000);
//});

//self.addEventListener("fetch", function (event) {
//        event.respondWith(verify(event));
//});

//async function verify(event) {
//    //Si la peticion va a la API
//    if (event.request.url.includes("/api/")) {
//        if (event.request.method == "GET") {
//            //Ver si ya hay una cache guardada con esa peticion
//            let saved = await caches.match(event.request);
//            //Si ya hay una guardada
//            if (saved) {
//                //Para obtener el ID de la pagina que voy a actualizar
//                let clientId = event.clientId;
//                //saved es nuestra cache que ya esta "obsoleta"
//                revalidate(saved.clone(), clientId);
//                //Revalidamos y regresamos la que teniamos ya guardada.
//                return saved;
//            }
//            else {
//                return cacheFirst(event.request);
//            }
//        }
//        else {
//            //Fue un POST, PUT o DELETE
//            if (navigator.onLine == true) {
//                //Si tengo internet hago un fetch normal
//                return fetch(event.request);
//            }
//            else {

//                //Guardar el request en idb
//                saveRequest(event.request);
//                //guardar el objeto en almacen temporal para mostrarlo en la vista
//                return new Response(null, { status: 200 });
//            }
//        }
//    }
//    else {
//        return cacheFirst(event.request);
//    }
//}
////Metodo para revalidar la informacion que teniamos ya en cache
//async function revalidate(request, clientId) {
//    //Hacemos la peticion a la API
//    let response = await fetch(request.url);
//    //Si regresa un ok.
//    if (response.ok) {
//        //Obtenemos un clone de la respuesta
//        let clone = response.clone();
//        //Con esto obtengo la respuesta de la API pero en modo texto  para compararla con el cache
//        let responseText = await response.text();
//        //Esto es lo que tenia cache pero texto para compararla con la de la API
//        let cacheText = await request.text;
//        //Si lo que regreso la peticion es diferente a lo que tenia el cache
//        if (responseText != cacheText) {
//            //Abrimos cache para guardarlo
//            let cache = await caches.open("cacheAPI");
//            //Actualizamos el contenido del cache con lo que tiene result
//            await cache.put(response.url, clone);

//            //Clients es una propiedad que tiene el service worker que identificar los usuarios que tiene registados
//            let page = await clients.get(clientId);
//            //HAcemos un postMessage para avisar a la pagina de un cambio
//            page.postMessage({
//                url: request.url,
//                data: JSON.parse(responseText)
//            });
//        }
//    }
//}

//async function saveRequest(request) {
//    //Hacemos el request para guardarlo en la bd
//    let myRequest = {
//        url: request.url,
//        method: request.method,
//        body: await request.json()
//    };
//    //Abrimos la bd
//    var response = indexedDB.open("mensajesDb");
//    response.onsuccess = function (event) {
//        var db = event.target.result;
//        var tx = db.transaction('peticiones', 'readwrite');
//        var store = tx.objectStore('peticiones');
//        //Guardamos el request
//        store.add(myRequest)
//    }
//}

//async function cacheFirst(request) {
//    caches.match(request).then((cacheResponse) => {
//        return cacheResponse || fetch(request).then((networkResponse) => {
//            return caches.open("cacheAPI").then((cache) => {
//                cache.put(request, networkResponse.clone());
//                return networkResponse;
//            })
//        })
//    })
//};

//async function forwardSavedRequests() {
//    //Abrimos la bd
//    var response = indexedDB.open("mensajesDb");
//    //Callback
//    response.onsuccess = function (event) {
//        var db = event.target.result;
//        //Iniciamos transaccion
//        var tx = db.transaction('peticiones', 'readwrite');
//        //Nos traemos el object store
//        var res = tx.objectStore('peticiones').getAll();
//        res.onsuccess = async function () {
//            let peticion = res.result;
//            for (var i = 0; i < peticion.length; i++) {

//                let response = await fetch(peticion[i].url, {
//                    method: peticion[i].method,
//                    body: JSON.stringify(peticion[i].body),
//                    headers: {
//                        "content-type": "application/json"
//                    }
//                });

//                if (response.ok) {
//                    var tx = db.transaction('peticiones', 'readwrite');
//                    tx.objectStore('peticiones').delete(peticion[i]);
//                    i--;
//                }
//            }

//        };
//    }
//}

self.addEventListener("fetch", function (event) {
    event.respondWith(verify(event));
});

async function verify(event) {
    //Si la peticion va a la API
    if (event.request.url.includes("/api/" && event.request == "GET")) {

        //Abrimos cache
        let cache = await caches.open("cacheAPI");
        //Ver si ya hay una cache guardada con esa peticion
        let saved = await cache.match("cacheAPI");
        //Si ya hay una guardada
        if (saved) {
            //Para obtener el ID de la pagina que voy a actualizar
            let clientId = event.clientId;
            //saved es nuestra cache que ya esta "obsoleta"
            revalidate(saved.clone(), clientId);
            //Revalidamos y regresamos la que teniamos ya guardada.
            return saved;
        }
        //Sino tenemos nada guardado en cache
        else if (event.request.url.includes("/api/")) {
            if (navigator.onLine == true) {
                //Hacemos la peticion
                let result = await fetch(event.request);
                //Si me regresa un ok
                if (result.ok) {
                    //Actualizamos el contenido del cache con lo que tiene result                 
                    return result;
                }
            }
            else {
                saveRequest(event.request.clone);
            }
        }
    }
    //Sino va a /api
    else {
        return await fetch(event.request);
    }
}
//Metodo para revalidar la informacion que teniamos ya en cache
async function revalidate(request, clientId) {
    //Hacemos la peticion a la API
    let response = await fetch(request.url);
    //Si regresa un ok.
    if (response.ok) {
        //Obtenemos un clone de la respuesta
        let clone = response.clone();
        //Con esto obtengo la respuesta de la API pero en modo texto  para compararla con el cache
        let responseText = await response.text();
        //Esto es lo que tenia cache pero texto para compararla con la de la API
        let cacheText = await request.text;
        //Si lo que regreso la peticion es diferente a lo que tenia el cache
        if (responseText != cacheText) {
            //Abrimos cache para guardarlo
            let cache = await caches.open("cacheAPI");
            //Actualizamos el contenido del cache con lo que tiene result
            await cache.put(response.url, clone);

            //Clients es una propiedad que tiene el service worker que identificar los usuarios que tiene registados
            let page = await clients.get(clientId);
            //HAcemos un postMessage para avisar a la pagina de un cambio
            page.postMessage({
                url: request.url,
                data: JSON.parse(responseText)
            });
        }
    }
}

function saveRequest(request) {
    console.log(request);
}

//QUEDO PENDIENTE EL CACHE Y LO DE INDEXED DB ME DABA ERROR EN EL METODO DE RESPONDWITH, DECIA QUE NO DEVOLVIA UN RESPUESTA.