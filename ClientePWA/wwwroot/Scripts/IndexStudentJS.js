let select = document.querySelector("select");
let h1 = document.querySelector("h1");

function generateList(listMessages) {
    for (i = 0; i < listMessages.length; i++) {
        let option = document.createElement("option");
        option.id = listMessages[i].id;
        let fecha = new Date(listMessages[i].fechaEnvio).toLocaleDateString();
        h1.innerText = "Bienvenido(a)" + " " + localStorage.nameUser;
        option.innerText = listMessages[i].asunto + " " + "(" + "Fecha de envio:" + fecha + ")";
        select.appendChild(option);
    }
}
async function getListOfMessages() {
    let response = await fetch(localStorage.url + "alumno/" + localStorage.idUser);
    if (response.ok) {
        let listOfMessages = await response.json();
        localStorage.messages = listOfMessages;
        generateList(listOfMessages);
    }
    else {
        console.log(response.status);
    }
}
getListOfMessages();

select.addEventListener("click", function (event) {
  localStorage.studentIdMessage = event.target.id;
});
