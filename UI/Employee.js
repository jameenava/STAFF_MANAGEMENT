// JavaScript source code
//fetch('https://localhost:44333/api/staff')
//    .then(response => {
//        console.log(response)
//    })
//const fetchPromise = fetch("https://localhost:44333/api/staff", { mode: "no-cors" });
//fetchPromise.then(response => {
//    return response.json();
//}).then(people => {
//    console.log(people);
//});
//fetch('https://localhost:44333/api/staff/teaching')
//    .then(res => res.json())
//    .then(data => console.log(data));
function showForm() {
   // debugger;
    var selopt = document.getElementById("ID").value;
    if (selopt == 1) {
        
        fetch("https://localhost:44333/api/staff/teaching").then(
            res => {
                res.json().then(
                    data => {
                        console.log(data.data);
                        if (data.length > 0) {

                            var temp = " ";
                            data.forEach((itemData) => {
                                temp += "<tr>";
                                temp += "<td>" + itemData.staffID + "</td>";
                                temp += "<td>" + itemData.employeeID + "</td>";
                                temp += "<td>" + itemData.institute + "</td>";
                                temp += "<td>" + itemData.salary + "</td>";
                                temp += "<td>" + itemData.subject + "</td>"
                                temp += "<td>" + itemData.designation + "</td></tr>"
                            });
                            document.getElementById('data1').innerHTML = temp;
                        }
                    }
                )
            }
        )
        document.getElementById("t1").style.display = "table";
        document.getElementById("t2").style.display = "none";
        document.getElementById("t3").style.display = "none";
    }
    if (selopt == 2) {
        
        fetch("https://localhost:44333/api/staff/administration").then(
            res => {
                res.json().then(
                    data => {
                        console.log(data.data);
                        if (data.length > 0) {

                            var temp = " ";
                            data.forEach((itemData) => {
                                temp += "<tr>";
                                temp += "<td>" + itemData.staffID + "</td>";
                                temp += "<td>" + itemData.employeeID + "</td>";
                                temp += "<td>" + itemData.institute + "</td>";
                                temp += "<td>" + itemData.salary + "</td>";
                                temp += "<td>" + itemData.adminArea + "</td>"
                                temp += "<td>" + itemData.designation + "</td></tr>"
                            });
                            document.getElementById('data2').innerHTML = temp;
                        }
                    }
                )
            }
        )
        document.getElementById("t1").style.display = "none";
        document.getElementById("t2").style.display = "table";
        document.getElementById("t3").style.display = "none";
    }

    if (selopt == 3) {
        
        fetch("https://localhost:44333/api/staff/supporting").then(
            res => {
                res.json().then(
                    data => {
                        console.log(data.data);
                        if (data.length > 0) {

                            var temp = " ";
                            data.forEach((itemData) => {
                                temp += "<tr>";
                                temp += "<td>" + itemData.staffID + "</td>";
                                temp += "<td>" + itemData.employeeID + "</td>";
                                temp += "<td>" + itemData.institute + "</td>";
                                temp += "<td>" + itemData.salary + "</td>";
                                temp += "<td>" + itemData.supportArea + "</td>"
                                temp += "<td>" + itemData.designation + "</td></tr>"
                            });
                            document.getElementById('data3').innerHTML = temp;
                        }
                    }
                )
            }
        )
        document.getElementById("t1").style.display = "none";
        document.getElementById("t2").style.display = "none";
        document.getElementById("t3").style.display = "table";
    }
}
//fetch('https://localhost:44333/api/staff/teaching')
//    .then(function (response) {
//        return response.json();
//    })
//    .then(function (data) {
//        appendData(data);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });
//function appendData(data) {
//    var mainContainer = document.getElementById("myData");
//    for (var i = 0; i < data.length; i++) {
//        {

//                        var temp = " ";
//                        temp += "<tr>";
//                        temp += "<td>" + data[i].staffID  + "</td>";
//                        temp += "<td>" + data[i].employeeID + "</td>";
               
//        //var div = document.createElement("div");
//        //div.innerHTML = 'Staff ID: ' + data[i].staffID + ' ' + 'Employee ID' + data[i].employeeID;
//        //mainContainer.appendChild(div);
//    }
//}