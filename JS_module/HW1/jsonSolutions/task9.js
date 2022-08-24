function combine(arr, separator)
{
  if (arr instanceof Array){
    let resultStr = String();
    for (let index = 0; index < arr.length; index++){
      resultStr = index + 1 == arr.length ? resultStr.concat(String(arr[index])) : resultStr.concat(String(arr[index]).concat(String(separator)));
    }
  
    return resultStr;
  }

  return null;
}

console.log(combine(["Ivanov", "Ivan", "Ivanovich"], "***"));