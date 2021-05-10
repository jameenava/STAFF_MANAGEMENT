// JavaScript source code
const myForm = document.getElementById('myForm');
myForm.addEventListener('submit', function (e) {
    e.preventDefault();
    const formData = new FormData(this);
    var object = {};
    formData.forEach(function (value, key) {
        object[key] = value;
    });
    var jsondata = JSON.stringify(object);
    fetch("https://localhost:44333/api/staff", {

        // Adding method type
        method: "POST",

        // Adding body or contents to send

        body: jsondata,

        // Adding headers to the request
        headers: {
            "Content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });

});
//function submitform() {
//    debugger;
//    //$("form").submit(function () {
//    //    console.log($(this).formToJson());
//    //    return false;
//    //});

//    var myForm = document.querySelector("form#myForm")
//    //var myForm = document.getElementById("myForm");
//    var data1 = {};
//    for (var formElement of myForm.childNodes.values()) {
//        if (formElement.name != "undefined") {
//            var key = formElement.name
//            var value = formElement.value

//            data1[key] = value
//        }
//    }
//        //var form = document.getElementById('myForm');
//        //var data = new FormData(form);
//        //for (var [key, value] of data) {
//        //    console.log(key, value)
//        //}
//        fetch("https://localhost:44333/api/staff", {

//            // Adding method type
//            method: "POST",

//            // Adding body or contents to send

//            body: JSON.stringify({
//                //Institute: document.getElementById("iname").value,
//                //StaffID: document.getElementById("sid").value,
//                //Subject: document.getElementById("sub").value,
//                //Salary: document.getElementById("sal").value,
//                //Designation: document.getElementById("stype").value
//                data1
//            }),

//            // Adding headers to the request
//            headers: {
//                "Content-type": "application/json; charset=UTF-8"
//            }
//        })

//            .then(response => response.json())
//            .then(data => {
//                console.log('Success:', data);
//            })
//            .catch((error) => {
//                console.error('Error:', error);
//            });
//    }