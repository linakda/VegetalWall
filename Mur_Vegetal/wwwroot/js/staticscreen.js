var elements = [];
var displayTimer = 5000;
var a = document.getElementById("a");
var a1 = a.getElementsByClassName("wall-block");
var b = document.getElementById("b");
var b1 = b.getElementsByClassName("news-block");
var c = document.getElementById("c");
var d = document.getElementById("d");
var d1 = document.getElementsByClassName("medias-block");
var e = document.getElementById("e");
a.style.display = "block";
b.style.display = "block";
c.style.display = "none";
d.style.display = "block";
e.style.display = "none";


elements.push(c, e);
fillElments();  
defile();
launchIntervail();
async function defile() {

  for (let i = 0; i < elements.length; i++) {
    if (i - 1 < 0) {
      elements[elements.length - 1].style.display = 'none';
    } else {
      elements[i - 1].style.display = 'none';
    }
    elements[i].style.display = 'flex';
    animate(elements[i]);
    await wait1Second();

  }
 
}

function wait1Second(x) {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(x);
    }, displayTimer);
  });
}
function launchIntervail(){
  setInterval(() => {
    defile();
  }, elements.length*displayTimer);
  
}

function fillElments(){
    for (let index = 0; index < b1.length; index++) {
      b1[index].style.display = "none";
      elements.push(b1[index]);
    }
    for (let index = 0; index < a1.length; index++) {
      a1[index].style.display = "none";
      elements.push(a1[index]);
    }
    for (let index = 0; index < d1.length; index++) {
      d1[index].style.display = "none";
      elements.push(d1[index]);
    }
}
function animate(element) {
  transition.begin(element, ["opacity 0 1 1s", "transform translateX(-200px) translateX(0px) 1s ease-in-out"]);
}