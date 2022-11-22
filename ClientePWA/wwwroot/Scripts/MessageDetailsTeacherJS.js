let pAffair = document.querySelector(".pAffair");
let p = document.querySelector(".MessageP");
let dateLabel = document.querySelector(".dateLabel");


async function getMessageById() {
    let response = await fetch(localStorage.url + "Docente/DetallesMensaje/" + localStorage.idMessage);
    if (response.ok) {
        let jsonMessage = await response.json();
        pAffair.innerText = jsonMessage.asunto;
        p.innerText = jsonMessage.mensajeEnviado;
        let fecha = new Date(jsonMessage.fechaEnvio).toLocaleDateString();
        dateLabel.innerText = fecha;
    }
    else {
        console.log(response.status);
    }
}

getMessageById();