var frameDiv = new Map();
var frameValidDiv = new Map();
var frameTimers = new Map();
var frameTimer;
var currentFrameIndex = 0;
var lastFrameIndex;

var frame = {
    init(walltime, newstime, countdowntime, mediastime, socialnetworkstime){
        let wall = $(".wall-frame:first");
        let news = $(".news-frame:first");
        let countdown = $(".countdown-frame:first");
        let medias = $(".medias-frame:first");
        let socialnetworks = $(".socialnetworks-frame:first");

        frameDiv.set('wall', wall);
        frameDiv.set('news', news);
        frameDiv.set('countdown', countdown);
        frameDiv.set('medias', medias);
        frameDiv.set('socialnetworks', socialnetworks);

        frameTimers.set('wall', walltime);
        frameTimers.set('news', newstime);
        frameTimers.set('countdown', countdowntime);
        frameTimers.set('medias', mediastime);
        frameTimers.set('socialnetworks', socialnetworkstime);

        for (const [key, value] of frameDiv.entries()) {
            value.css("display","none");
        };

        if (typeof frameTimer !== 'undefined') {
            clearTimeout(frameTimer);
        };

        for (const [key, value] of frameTimers.entries()) { //check how many null timers there is
            if (!isNaN(value) && value != null && value != 0){ //if its a number
                frameValidDiv.set(key,frameDiv.get(key));
            }
        };

        lastFrameIndex = frameValidDiv.size -1;
        frame.roll(); //Start frame animation
    },

    roll(){
        let thisFrame = Array.from(frameValidDiv)[currentFrameIndex][1]; //Get current frame html element
        let thisFrameName = Array.from(frameValidDiv)[currentFrameIndex][0];
        let timing = frameTimers.get(thisFrameName); //Get current frame timer

        thisFrame.css("display","grid"); //Display current frame element

        currentFrameIndex++;

        if(currentFrameIndex>lastFrameIndex){ //Check if its the last frame element
            currentFrameIndex=0;
        }

        if (thisFrameName == "news" || thisFrameName == "medias"){
            console.log('caroussel');
        }

        frameTimer = setTimeout(function(){
            let previousFrameIndex = currentFrameIndex-1; //Get previous frame
    
            // If previous was last frame
            if(previousFrameIndex == -1){
                previousFrameIndex = lastFrameIndex;
            }

            Array.from(frameValidDiv)[previousFrameIndex][1].css("display","none"); //Remove previous frame

            frame.roll();
        }, timing*1000);

    },

    animateIn(element) {
        
    },
    animateOut(element) {
        
    }
}