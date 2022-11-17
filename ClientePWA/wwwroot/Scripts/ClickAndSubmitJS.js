let formLogin = document.getElementById(".formLogin");

document.addEventListener("click", function (event) {
    //Cuando se da click a la a del login
    if (event.target.dataset.login) {
        let email = formLogin.elements["email"];
        let password = formLogin.elements["password"];

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
    }
    if (event.target.dataset.add) {
        window.location.replace("/Teachers/AddMessage");
    }
    if (event.target.dataset.update) {
        window.location.replace("/Teachers/UpdateMessage");
    }
    if (event.target.dataset.delete) {
        alert("Pendiente crear un modal para eliminar");
    }
    if (event.target.dataset.details) {
        window.location.replace("/Teachers/MessageDetailsTeacher");
    }
    if (event.target.dataset.logout) {
        window.location.replace("/Home/Login");
    }
    if (event.target.dataset.sendmessage) {
        let affair = form.elements["affair"].value;
        let message = form.elements["message"].value;
        console.log(affair);
        console.log(message);
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.cancelteacher) {
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.updatemessage) {
        let affair = form.elements["affair"].value;
        let message = form.elements["message"].value;
        console.log(affair);
        console.log(message);
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.cancelstudent) {
        window.location.replace("/Students/Index");
    }
    if (event.target.dataset.detailsstudent) {
        window.location.replace("/Students/MessageDetailsStudent");
    }
});