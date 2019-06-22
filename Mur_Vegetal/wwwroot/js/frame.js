var frameDiv = new Map();
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

        lastFrameIndex = frameDiv.size -1;

        let triggerStart = 0;
        let tempNameTrigger = "";
        for (const [key, value] of frameTimers.entries()) { //check how many null timers there is
            if (!isNaN(value) && value != null && value != 0){ //if its a number
                triggerStart++;
                tempNameTrigger = key;
            }
        };

        if (triggerStart == 1){
            console.log('Only 1 frame to display. No animation.');
            frameDiv.get(tempNameTrigger).css("display","grid");
        }
        else if (triggerStart < 1){
            console.log('Nothing to display');
        }
        else {
            console.log('Starting frames display. ',triggerStart,' frames to display');
            frame.start(); //Start frame animation
        }
    },

    start(){
        let thisFrame = Array.from(frameDiv)[currentFrameIndex][1]; //Get current frame html element
        let timing = frameTimers.get(Array.from(frameDiv)[currentFrameIndex][0]); //Get current frame timer

        thisFrame.css("display","grid"); //Display current frame element

        currentFrameIndex++;

        if(currentFrameIndex>lastFrameIndex){ //Check if its the last frame element
            currentFrameIndex=0;
        }

        frameTimer = setTimeout(function(){
            let previousFrameIndex = currentFrameIndex-1; //Get previous frame
    
            // If previous was last frame
            if(previousFrameIndex == -1){
                previousFrameIndex = lastFrameIndex;
            }

            Array.from(frameDiv)[previousFrameIndex][1].css("display","none"); //Remove previous frame

            frame.start();
        }, timing*1000);

    },

    animateIn(element) {
        
    },
    animateOut(element) {
        
    }
}