const url2 = "http://pwa-mensajes-181g0231.itesrc.net/api/";

document.addEventListener("click", function (event) {
    
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

document.addEventListener("submit", async function (event) {
        //Para cancelar el evento submit, (Override) para poder programar lo que queramos que pase cuando se haga un submit
    event.preventDefault();
    let form = event.target;
    if (event.target.dataset.login) {
         if (event.target.dataset.login) {
        if (form.elements["email"].value) {
            if (form.elements["contraseña"].value) {
                
                if (form.elements["email"].value == "2609@rcarbonifera.tecnm.mx" && form.elements["contraseña"].value == "Hector123") {
                    window.location.replace("/Teachers/Index");
                }
                else if (form.elements["email"].value == "181G0231@rcarbonifera.tecnm.mx" && form.elements["contraseña"].value == "Luis123") {
                    window.location.replace("/Students/Index");
                }
                else {
                    alert("Usuario o contraseña incorrecto. Despues lo sustituire por un error en un label si es incorrecto");
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
    }
    //if (event.target.dataset.login) {
    //    if (form.elements["email"].value) { 
    //        if (form.elements["contraseña"].value) {
    //            let jsonLogin = Object.fromEntries(new FormData(form));
    //            const requestInfo = {
    //                method: "POST",
    //                body: JSON.stringify(jsonLogin),
    //                mode: 'cors',
    //                headers: {
    //                    'Content-type': 'application/json'
    //                }
    //            };
    //            let response = await fetch(`${url2}${form.dataset.action}`, requestInfo);
    //            if (response.ok) {
    //                console.log(response.body);
    //                console.log(response.headers);
    //                form.reset();
    //            }
    //            else {
    //                console.log(response.status);
    //                console.log(response.statusText);
    //            }
    //        }
    //        else {
    //            password.setCustomValidity('Proporcione su contraseña');
    //            password.reportValidity();
    //        }
    //    }
    //    else {
    //        email.setCustomValidity('Proporcione su correo electronico');
    //        email.reportValidity();
    //    }
       
    //}

});