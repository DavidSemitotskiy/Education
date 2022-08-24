function squarePolygon(num){
  if (typeof(num) == "number" && num > 0){
    return (num * num) + ((num - 1) * (num - 1));
  }

  return 0;
}

console.log(squarePolygon(2));
console.log(squarePolygon(3));
console.log(squarePolygon(4));
console.log(squarePolygon(5));