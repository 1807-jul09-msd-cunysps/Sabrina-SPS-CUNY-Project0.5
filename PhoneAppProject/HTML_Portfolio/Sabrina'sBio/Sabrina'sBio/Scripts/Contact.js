

//string
/*
var name = "Kevin";
alert(`hello ${name.toUpperCase()}`);
*/

//undefined
/*
let dummy;
alert(dummy);
*/
//boolean




//Functions


//1.Declarative or named functions
//FuncExp();
//(function Welcome() {
//    var name = prompt("Please enter your name:");
//    alert(`Welcome ${name}`);
//})();


//Parameterized 
//function Add(...params) {
//    var temp = 0;
//    for (var a in params) {
//        temp += params[a];
//    }
//    return temp;
//}
//alert(Add(10, 20, 40));

//Anonymous functions having anonymous functions
//var wish = function () {
//    alert('My pleasure');
//}
//wish();


//IIFE with parameterised anonymous functions
//(function (a, b) {
//    alert(a + b);
//})(12, 15);

//IIFE: Immediate Invoked Function Expression
//Lambda Functions
/*((a,b) => alert(a+b))(10, 45); *///lambda IIFE
//var add = (a, b) => alert(a, b);//lambda Function Expression
//add(10, 45);

//Function Constructor
//var Multiply = new Function("x", "");


//Closures
//function Outer() {
//    //Outer is the self-invoking function and it runs only once
//    var outerdata = "Hello CUNY-SPS-Rev";
//    function Inner() {
//        alert(outerdata)
//    }
//    return Inner;
//}

//var func = Outer();
//func();

//Arrays
//var countries = ["United Kingdom", "China", "Italy", "Japan", "France"];
//alert(countries.length);
//for (var i = 0; i < countries.length; i++) {
//    alert(countries[i]);
//}
/*
for (var i in countries) {
    alert(countries[i]);
}
*/

//var product = ["iphoneX: 999.00", "Chips: 10.00", "Earphone: 100.00", "Case: 15.00", "gum: 10.00"];
//var count = 0;
//for (var i in product) {
//    var split = product[i].split(':');
//    count += Number(split[1]);
//}
//alert(`Total: ${count}`);

//var doc = document.getElementById("exampleFirstName");
//doc.addEventListener



        //clone
        //event bubbling, child to parent
        //event bubbling, child to parent
        //event capturing, parent to child

       //if (this.addEventListener) {
       //     var firstName = document.getElementById("exampleFirstName");
       //     firstName.addEventListener("blur", Welcome);
       // }

var addrElem = document.querySelector("#checkAddress");
checkAddr.onblur = checkAdd();



function checkAdd() {
    //debugger;
    var check = document.querySelector("#checkAddress").value;
    if (check == "No") {
        var address2 = document.querySelector("#address2");
        var city2 = document.querySelector("#city2");
        var state2 = document.querySelector("#state2");
        var country2 = document.querySelector("#country2");
        var h3 = document.createElement("h3"); //Creates new element in DOM tree
        h3.innerText = "Permanent Addess";
        var lbladd1 = document.createElement("label");
        lbladd1.innerText = "Address Line 1 ";
        var add1 = document.createElement("input");
        var lblCity = document.createElement("label");
        lblCity.innerText = "City ";
        var lblState = document.createElement("label");
        lblState.innerText = "State "
        var lblCountry = document.createElement("label");
        lblCountry.innerText = "Country ";
        var city = document.createElement("input");
        var state = document.createElement("input");
        var country = document.createElement("select");
        country.className.value = "bfh-countries";
        country.required;

        address2.appendChild(h3);
        address2.appendChild(lbladd1);
        address2.appendChild(add1);
        city2.appendChild(lblCity);
        city2.appendChild(city);
        state2.appendChild(lblState);
        state2.appendChild(state);
        country2.appendChild(lblCountry);
        country2.appendChild(country);
    }
}

function Welcome() {
    var firstName = document.querySelector("#exampleFirstName").value;
    var data = document.querySelectorAll("input");
    alert(`Welcome ${firstName}`);
}

function locationPopulate(json) {
    debugger;
    // var json = { "zip_code": "10017", "lat": 0.711263, "lng": -1.29106, "city": "New York", "state": "NY", "timezone": { "timezone_identifier": "America\/New_York", "timezone_abbr": "EDT", "utc_offset_sec": -14400, "is_dst": "T" }, "acceptable_city_names": [{ "city": "Grand Central", "state": "NY" }, { "city": "Manhattan", "state": "NY" }, { "city": "Nyc", "state": "NY" }] };
    json = JSON.parse(json);
    var state = document.getElementById("State");
    var city = document.getElementById("City");
    state.value = json.state;
    city.value = json.city;
}

function checkZipcodeWithFile() {

    var zipcode = document.getElementById("zipcode").value;
    var url = "../zipcode.txt";
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.onreadystatechange = function (e) {    //Call a function when the state changes.
        if (this.readyState == XMLHttpRequest.DONE && this.status == 200) {
            var result = xhr.responseText;
            if (result !== null || result !== "" || result !== undefined) {
                if (result.charAt(0) === '"' && result.charAt(result.length - 1) === '"') {
                    result = result.substr(1, result.length - 2);
                }
                debugger;
                locationPopulate(result);
            }

        }
    }
    xhr.send();
}

function checkZipcode() {
    debugger;
    var zipcode = document.getElementById("zipcode").value;
    var clientKey = "js-WuScLxcZ2oBa71EDWgHrxMPxtqy5XsqNCZg2fFiaQgK9PXqXFoaCO5VXnwh7BavA";
    var url = "https://www.zipcodeapi.com/rest/" + clientKey + "/info.json/" + zipcode + "/radians";
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.onreadystatechange = function () {    //Call a function when the state changes.
        if (this.readyState == XMLHttpRequest.DONE && this.status == 200) {
            var result = xhr.responseText;
            if (result !== null || result !== "" || result !== undefined) {
                if (result.charAt(0) === '"' && result.charAt(result.length - 1) === '"') {
                    result = result.substr(1, result.length - 2);
                }
                //debugger;
                locationPopulate(result);
            }

        }
    }
    xhr.send();
}


function validFirstName() {
    var fName = document.forms["ContactForm"]["firstName"];
    fName.required = true;
}

function validLastName() {
    var lName = document.forms["ContactForm"]["lastName"];
    lName.required = true;
}

function validAge() {
    var age = document.getElementById("#exampleAge");
    age.title = "Please enter a valid age."
    if (!isNaN(age)) {
        if(age.)
        return true;
    } else {
        return false;
    }
    
}

function validGender() {
    var gender = document.forms["ContactForm"]["gender"];
    gender.required = true;

}

function validate() {
    var fName = document.forms["ContactForm"]["firstName"];
    var lName = document.forms["ContactForm"]["lastName"];
    var age = document.forms["ContactForm"]["Age"];
    var gender = document.forms["ContactForm"]["gender"];
    var zip = document.forms["ContactForm"]["zip"];
    var address = document.forms["ContactForm"]["address1"];
    var state = document.forms["ContactForm"]["state"];
    var city = document.forms["ContactForm"]["city"];
    var country = document.forms["ContactForm"]["country"];
    var countryCode = document.forms["ContactForm"]["countryCode"];
    var areaCode = document.forms["ContactForm"]["areaCode"];
    var phone = document.forms["ContactForm"]["phone"];
    var ext = document.forms["ContactForm"]["ext"];
    fName.required = true;
    lName.required = true;
    age.required = true;
    gender.required = true;
    zip.required = true;
    address.required = true;
    if (country.value == "US") {
        state.required = true;
    } else {
        state.required = false;
    }

    city.required = true;
    country.required = true;
    countryCode.required = true;
    if (country.value == "US") {
        areaCode.required = true;
    } else {
        areaCode.required = false;
    }
    phone.required = true;

    var numbers = /^[0-9]+$/;

    if ((fName.value == lName.value)) {
        window.alert("Please enter different first and last names.");
        fName.focus();
        lName.focus();
        return false;
    }

    if (age.value < 15) {
        window.alert("Please enter a valid age.");
        age.focus();
        return false;
    }

    if (zip.value.match(numbers)) {
        window.alert("Please enter only numbers.");
        zip.focus();
        return false;
    }

    if (areaCode.value.match(numbers)) {
        window.alert("Please enter only numbers");
        areaCode.focus();
        return false;
    }

    if (phone.value.match(numbers)) {
        window.alert("Please enter only numbers");
        phone.focus();
        return false;
    }

    if ((ext.value != "") && (ext.value.match(numbers))) {
        window.alert("Please enter numbers only");
    }
}

   

    