var elements= [] ; 
var timers = [] ; 
var displayTimer = 5000;
var timerCountdown  = 5000 ;
var timerWall = 5000;
var timerInsta = 5000; 
var wall = document.getElementById("a");//WALL
var news = document.getElementById("b");
var tabsNews = news.getElementsByClassName("news-block");//NEWS
var countdown = document.getElementById("c");//COMPTEUR
var medias= document.getElementById("d");
var tabMedias = medias.getElementsByClassName("medias-block");//MEDIAS
var insta = document.getElementById("e");//INSTA
wall.style.display = "none";
news.style.display = "block";
countdown.style.display = "none";
medias.style.display = "block";
insta.style.display = "none";



<<<<<<< HEAD
elements.push(c,e);
=======
>>>>>>> de7f8676af0f38154747c5ea7dd1e1c09bd06e94
fillElments();  
defile();
launchIntervail();

async function defile() {
  if (elements.length === timers.length ) {
    for (let i = 0; i < elements.length; i++) {
      if (i - 1 < 0) {
        elements[elements.length - 1].style.display = 'none';
      } else {
        elements[i - 1].style.display = 'none';
      }
      elements[i].style.display = 'flex';
      animate(elements[i]);
      await wait1Second(timer[i]);
  
    }
   
  }
  else{
    document.write("<H1>WESH C4EST pas la même taille</H1>");
  }
}
function wait1Second(displayTimer) {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve();
    }, displayTimer);
  });
}
function launchIntervail(){
  setInterval(() => {
    defile();
  }, elements.length*displayTimer);
  
}

function fillElments(){
  elements.push(wall, countdown, insta);
  timers.push(timerWall , timerCountdown , timerInsta ); 
    for (let index = 0; index < tabsNews.length; index++) {
      tabsNews[index].style.display = "none";
      elements.push(tabsNews[index]);
      timers.push(displayTimer); 
    }
  
    for (let index = 0; index < tabMedias.length; index++) {
      tabMedias[index].style.display = "none";
      elements.push(tabMedias[index]);
      timers.push(displayTimer);
    }
}
function animate(element) {
  transition.begin(element, ["opacity 0 1 1s", "transform translateX(-200px) translateX(0px) 1s ease-in-out"]);
}

function modifyTime(timerCountdown,timerInsta,timerWall){
    this.timerCountdown = timerCountdown ; 
    this.timerInsta = timerInsta ; 
    this.timerWall = timerWall ; 
}

