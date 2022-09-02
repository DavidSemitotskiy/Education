class Validator{
  isValid(str){}
}

class EmailValidator extends Validator{
  #emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
  isValid(str){
    if (typeof(str) == "string"){
      return this.#emailRegex.test(str);
    }

    return false;
  }
}

class PhoneValidator extends Validator{
  #phoneRegex = /^\+380\d{9}$/;
  isValid(str){
    if (typeof(str) == "string"){
      return this.#phoneRegex.test(str);
    }

    return false;
  }
}

console.log("TASK4")
let emailValidator = new EmailValidator();
console.log(emailValidator.isValid("da_jda12wda@gmail.com"));
let phoneValidator = new PhoneValidator();
console.log(phoneValidator.isValid("+380635290289"));