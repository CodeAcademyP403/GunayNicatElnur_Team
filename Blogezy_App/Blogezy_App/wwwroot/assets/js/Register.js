//Get Role value
var getSectionValue = document.querySelector("#inputRole");

// for Regsiter teacher and student
var forTeacherSection = document.querySelector("#Teacher");
var forStudentSection = document.querySelector("#Student");

//Select User Role with Section/Option
getSectionValue.addEventListener("change", function () {
    var value = getSectionValue.value;

    if (value == 1) {
        //For Student Hide
        forStudentSection.style.height = "0px";
        forStudentSection.style.opacity = "0";
        forStudentSection.style.overflow = "hidden";

        //For Teacher Show
        forTeacherSection.style.height = "100px";
        forTeacherSection.style.opacity = "1";
        forTeacherSection.style.overflow = "visible";

    }
    else if (value == 2) {
        //For Teacher Hidden
        forTeacherSection.style.height = "0px";
        forTeacherSection.style.opacity = "0";
        forTeacherSection.style.overflow = "hidden";

        //For Student Show
        forStudentSection.style.height = "250px";
        forStudentSection.style.opacity = "1";
        forStudentSection.style.overflow = "visible";
    }
});