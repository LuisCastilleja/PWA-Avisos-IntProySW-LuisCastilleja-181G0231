﻿let pAffair = document.querySelector(".pAffair");
let p = document.querySelector(".MessageP");
let dateLabel = document.querySelector(".dateLabel");
let aBack = document.querySelector(".aBack");

p.innerText = " Augusta Ada King (1815-1852), conocida habitualmente como Ada Lovelace, fue una matemática británica. Es considerada como la primera programadora, desde que escribió la manipulación de los símbolos, de acuerdo a las normas para una máquina de Charles Babbage que aún no habí­a sido construida.  Ella dedujo y previó la capacidad de los ordenadores para ir más allá de los simples cálculos de números, mientras que otros, incluido el propio Babbage, se centraron únicamente en estas capacidades.                     Ada conoció a Mary Somerville, una conocida autora y científica del siglo XIX que le presentó a Charles Babbage(profesor Lucasiano de matemáticas en la Universidad de Cambridge y padre de las computadoras) el 5 de junio de 1833, cuando ella sólo tenía 17 años.                     De inmediato comenzó una voluminosa correspondencia entre ambos sobre temas relacionados con las matemáticas, la lógica, y en última instancia, todas las materias.Charles Baggage quedó tan impresionado con la capacidad analítica de la joven Ada que la apodó como “La encantadora de números“.";
pAffair.innerText = "Augusta Ada King (1815-1852), conocida habitualmente como Ada Lovelace, fue una matemática británica. Es considerada como la primera programadora, desde que escribió la manipulación de los símbolos, de acuerdo a las normas para una máquina de Charles Babbage que aún no habí­a sido construida.                    Ada Lovelace, primer programador en la historia";
dateLabel.innerText = "2022/11/01";

aBack.addEventListener("click", function (event) {
    window.location.replace("/Students/Index");
});