function getArrayFromObject(obj){
  let mainArray = new Array();
  let tuple = new Array();
  let keysObject = Object.keys(obj);
  let valuesObject = Object.values(obj);
  for (let i = 0; i < keysObject.length; i++){
    tuple.push(keysObject[i]);
    tuple.push(valuesObject[i]);
    mainArray.push(tuple);
    tuple = new Array();
  }

  return mainArray;
}

console.log("TASK3");
let obj2 = {
  name: "David",
  age: 18,
  getInfo: function() {
    return this.name + " " + this.age;
  }
}
console.log(getArrayFromObject(obj2));