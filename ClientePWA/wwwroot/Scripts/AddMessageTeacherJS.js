var listOfStudents = [
    {
        NombreCompleto: "Luis Enrique Castilleja Tristán",
        Correo: "181G0231@rcarbonifera.tecnm.mx",
    },
    {
        NombreCompleto: "Karla Veronica Lopez Tovar",
        Correo: "181G0138@rcarbonifera.tecnm.mx"
    },
    {
        NombreCompleto: "Abraham Antonio Torres Martinez",
        Correo: "181G0531@rcarbonifera.tecnm.mx"
    }
];
var listOfGroups = [
    {
        Grupo: "8.2G",
        ListaEstudiantes: listOfStudents,
    },
    {
        Grupo:"9.1G",
        ListaEstudiantes: listOfStudents,
    },
    {
        Grupo: "7.1G",
        ListaEstudiantes: listOfStudents,
    }
];
var listOfSpecialties = [
    {
        Especialidad: "Ing. Sistemas computacionales",
        ListaGrupos: listOfGroups,
    },
    {
        Especialidad: "Ing. Mecatronica",
        ListaGrupos: listOfGroups,
    },
    {
        Especialidad: "Ing. Petrolera",
        ListaGrupos: listOfGroups,
    }
];

//Elementos
let recipient = document.querySelector("input[type=text]");
let inputFilter = document.querySelector(".inputFilter");
let select = document.querySelector("select");
let selectFilter = document.querySelector(".selectFilter")
let addButton = document.querySelector("input[type=button]");
let removeInput = document.querySelector(".removeInput");
let removeButton = document.querySelector(".removeButton");
let listOfRecipients = document.querySelector(".listOfRecipients");

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
                option.innerText = value.NombreCompleto;
                select.appendChild(option);
            });
        }
        else if (typeOfFilter == "Grupos") {
            list.forEach(value => {
                let option = document.createElement("option");
                option.innerText = value.Grupo;
                select.appendChild(option);
            });
        }
        else {
            list.forEach(value => {
                let option = document.createElement("option");
                option.innerText = value.Especialidad;
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

//Rellenar los filtros
fillFilters();
//Tener por defecto un listado y un filtro seleccionado
filterSelect(listOfStudents, "Estudiantes");
inputFilter.value = "Estudiantes";
selectFilter.options[0].selected = true;

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
        if (select.hasChildNodes()) {
            while (select.options.length > 0) {
                select.remove(select.options.length - 1);
            }
        }
        filterSelect(listOfStudents, "Estudiantes");
    }
    else if (inputFilter.value == "Grupos") {
        if (select.hasChildNodes()) {
            while (select.options.length > 0) {
                select.remove(select.options.length - 1);
            }
        }
        filterSelect(listOfGroups, "Grupos");
    }
        else {
            if (select.hasChildNodes()) {
                while (select.options.length > 0) {
                    select.remove(select.options.length - 1);
                }
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
