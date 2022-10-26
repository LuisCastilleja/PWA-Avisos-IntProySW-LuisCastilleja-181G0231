var listMessages = [
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto cambiado",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
      {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },

    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },

    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto changeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
]
let listDiv = document.querySelector(".listDiv");
function generateList() {
    for (let message of listMessages) {
        let div = document.createElement("div");
        let a = document.createElement("a");
        let aFecha = document.createElement("a");
        a.innerText = "Asunto:" + " " + message.Asunto + " ";
        aFecha.innerText = message.Fecha;
        div.append(a, aFecha);
        listDiv.appendChild(div);
    }
}
generateList();

