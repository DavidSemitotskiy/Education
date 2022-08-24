function maxMultiply(arr){
  if (arr instanceof Array){
    let maxMult = 0;
    for (let index = 0; index < arr.length - 1; index++){
      if (arr[index] * arr[index + 1] > maxMult){
        maxMult = arr[index] * arr[index + 1];
      }
    }

    return maxMult;
  }
}

console.log(maxMultiply([3, 6, -2, -5, 7, 3]));