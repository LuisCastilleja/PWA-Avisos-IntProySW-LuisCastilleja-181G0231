self.addEventListener("fetch", function (event) {
  //  event.respondWith(verify(event));
});

//async function verify(event) {
//    //Si la peticion va a la API
//    if (event.request.url.includes("/api/" && event.request == "GET")) {

//        //Abrimos cache
//        let cache = await caches.open("cacheAPI");
//        //Ver si ya hay una cache guardada con esa peticion
//        let saved = await cache.match("cacheAPI");
//        //Si ya hay una guardada
//        if (saved) {
//            //Para obtener el ID de la pagina que voy a actualizar
//            let clientId = event.clientId;
//            //saved es nuestra cache que ya esta "obsoleta"
//            revalidate(saved.clone(), clientId);
//            //Revalidamos y regresamos la que teniamos ya guardada.
//            return saved;
//        }
//        //Sino tenemos nada guardado en cache
//        else {
//            //Hacemos la peticion
//            let result = await fetch(event.request);
//            //Si me regresa un ok
//            if (result.ok) {
//                //Actualizamos el contenido del cache con lo que tiene result
//                await cache.put(event.request, result.clone());
//                return result;
//            }

//        }
//    }
//    //Sino va a /api
//    else {
//        return await fetch(event.request.url);
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