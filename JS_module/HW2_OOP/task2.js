function showObjectStructure(obj){
  let keys = Object.keys(obj);
  keys.forEach(value => console.log(value));
}

console.log("TASK2");
let obj1 = {
  name: "David",
  age: 18,
  getInfo: function() {
    return this.name + " " + this.age;
  }
}
showObjectStructure(obj1);