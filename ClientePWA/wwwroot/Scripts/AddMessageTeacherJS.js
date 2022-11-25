let recipient = document.querySelector("input[type=text]");
let inputFilter = document.querySelector(".inputFilter");
let select = document.querySelector("select");
let selectFilter = document.querySelector(".selectFilter")
let addButton = document.querySelector("input[type=button]");
let removeInput = document.querySelector(".removeInput");
let removeButton = document.querySelector(".removeButton");
let listOfRecipients = document.querySelector(".listOfRecipients");
let form = document.querySelector("form");

let listOfStudents = [];
let listOfGroups = [];
let listOfSpecialties = [];

async function getStudents() {
    let response = await fetch(localStorage.url + "Docente/Alumnos/" + localStorage.idUser);
    if (response.ok) {
        listOfStudents = await response.json();
        //Para dejar uno por defecto
        filterSelect(listOfStudents, "Estudiantes");
        inputFilter.value = "Estudiantes";
        selectFilter.options[0].selected = true;
    }
    else {
        console.log(response.status);
    }
}

async function getGroups() {
    let response = await fetch(localStorage.url + "Docente/Grupos/" + localStorage.idUser);
    if (response.ok) {
        listOfGroups = await response.json();
    }
    else {
        console.log(response.status);
    }
}

async function getSpecialties() {
    let response = await fetch(localStorage.url + "Docente/Especialidades/" + localStorage.idUser);
    if (response.ok) {
        listOfSpecialties = await response.json();
    }
    else {
        console.log(response.status);
    }
}


//Agregar destinatarios
function addRecipients() {
    if (recipient.value) {
        let option = document.createElement("option");
        option.innerText = recipient.value;
        recipient.value = "";
        listOfRecipients.appendChild(option);
    }
}

//Para remover un destinitario.
function removeRecipients() {
    if (removeInput.value) {
        listOfRecipients.options.remove(listOfRecipients.selectedIndex);
        removeInput.value = "";
    }
}

//Para pasar la lista que se mostrara en los destinatarios
function filterSelect(list, typeOfFilter) {
        if (typeOfFilter == "Estudiantes") {
            list.forEach(value => {
                let option = document.createElement("option");
                option.innerText = value.nombreCompleto;
                select.appendChild(option);
            });
        }
        else if (typeOfFilter == "Grupos") {
            list.forEach(value => {
                let option = document.createElement("option");
                option.innerText = value.nombre;
                select.appendChild(option);
            });
        }
        else {
            list.forEach(value => {
                let option = document.createElement("option");
                option.innerText = value.nombre;
                select.appendChild(option);
            });
        }
}

//Crear opciones de los filtros
function fillFilters() {
    let option1 = document.createElement("option");
    option1.innerText = "Estudiantes";
    let option2 = document.createElement("option");
    option2.innerText = "Grupos";
    let option3 = document.createElement("option");
    option3.innerText = "Especialidades";
    selectFilter.append(option1, option2, option3);
}

//Cuando de click a una opcion del select de agregar destinatarios
select.addEventListener("click", function (event) {
    let optionSelected = event.target;
    recipient.value = optionSelected.innerText;
});

//Cuando de click a una opcion del select de eliminar destinatarios.
listOfRecipients.addEventListener("click", function (event) {
    let optionSelected = event.target;
    removeInput.value = optionSelected.innerText;
});

//Cuando seleccione un filtro
selectFilter.addEventListener("click", function (event) {
    let selected = event.target;
    inputFilter.value = selected.innerText;
    if (inputFilter.value == "Estudiantes") {
        if (select.children) {
            select.replaceChildren();
        }
        filterSelect(listOfStudents, "Estudiantes");
    }
    else if (inputFilter.value == "Grupos") {
        if (select.children) {
            select.replaceChildren();
        }
        filterSelect(listOfGroups, "Grupos");
    }
    else {
        if (select.children) {
                select.replaceChildren();
        }
        filterSelect(listOfSpecialties, "Especialidades")
        }      
});


//Cuando de al boton agregar.
addButton.addEventListener("click", function () {
    addRecipients();
    //Pendiente borrar las opciones que ya selecciono
    //O que no las pueda seleccionar 
});

//Cuando de al boton eliminar destinatario
removeButton.addEventListener("click", function () {
    removeRecipients();
});

getStudents();
getGroups();
getSpecialties();

//Rellenar los filtros
fillFilters();
//Tener por defecto un listado y un filtro seleccionado

