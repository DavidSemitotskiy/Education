function date(){
  let date = new Date();
  let hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
  let minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
  let seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
  let element = document.getElementById("time");
  element.innerHTML = `${hours}:${minutes}:${seconds}`;
}
setInterval(date, 1000);