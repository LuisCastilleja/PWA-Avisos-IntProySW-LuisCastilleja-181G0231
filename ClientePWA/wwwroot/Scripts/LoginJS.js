let form = document.querySelector("form");
let a = document.querySelector("a");
a.addEventListener("click", function () {
    let email = form.elements["email"];
    let password = form.elements["password"];

    if (email.value) {
        if (password.value) {
            if (email.value == "2609@rcarbonifera.tecnm.mx" && password.value == "Hector123") {
                window.location.replace("/Teachers/Index");
            }
            else if (email.value == "181G0231@rcarbonifera.tecnm.mx" && password.value == "Luis123") {
                window.location.replace("/Students/Index");
            }
            else {
                //Despues sustituir por un label con el mensaje de error u otra cosa.
                alert("Usuario o contraseña incorrectos");
            }
        }
        else {
            password.setCustomValidity('Proporcione su contraseña');
            password.reportValidity();
        }
    }
    else {
        email.setCustomValidity('Proporcione su correo electronico');
        email.reportValidity();
    }



});