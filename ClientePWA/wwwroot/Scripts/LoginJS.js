let form = document.querySelector("form");
let a = document.querySelector("a");
a.addEventListener("click", function () {
    let email = form.elements["email"].value;
    let password = form.elements["password"].value;
    console.log(email);
    console.log(password);
    if (email == "2609@rcarbonifera.tecnm.mx" && password == "HectorPadilla") {
        window.location.replace("/Teachers/Index");
    }
    else if (email == "181G0231@rcarbonifera.tecnm.mx" && password == "LuisCastilleja") {
        window.location.replace("/Students/Index");
    }
    else {
        //Despues sustituir por un label con el mensaje de error u otra cosa.
        alert("Usuario o contraseña incorrectos");
    }
})