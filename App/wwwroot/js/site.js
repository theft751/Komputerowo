//**************** */
/*Universal methods*/
/**************** */

/*In this file there are some universal methods which can be useful in every type of page*/ 


function validateEmail(email){
return String(email)
    .toLowerCase()
    .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    );
};

//Arguements are HTML elements. True when password are the same
function validatePasswords(password, repeatedPassword) {
    if (repeatedPassword.value != "")
    {
        if (repeatedPassword.value == password.value) {
            return true
        }
        else {
            return false;
        }
    }
    else {
        return true;
    }
}

//Arguements are Strings. True when password are the same
function validatePasswordsStrings(password, repeatedPassword) {
    if (repeatedPassword != "") {
        if (repeatedPassword == password) {
            return true
        }
        else {
            return false;
        }
    }
    else {
        return true;
    }
}