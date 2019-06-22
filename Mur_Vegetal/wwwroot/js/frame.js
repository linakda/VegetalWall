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
    },

    start(){
        console.log('start');
        let thisFrame = Array.from(frameDiv)[currentFrameIndex][1]; //Get current frame html element
        let timing = frameTimers.get(Array.from(frameDiv)[currentFrameIndex][0]); //Get current frame timer
        console.log('frame index ', currentFrameIndex);
        console.log('frame name ', Array.from(frameDiv)[currentFrameIndex][0]);
        console.log('this timing ', timing);

        //frame.animateIn(thisFrame);
        thisFrame.css("display","grid"); //Display current frame element

        currentFrameIndex++;

        if(currentFrameIndex>lastFrameIndex){ //Check if its the last frame element
            currentFrameIndex=0;
            console.log('loop ended');
        }

        frameTimer = setTimeout(function(){
            let previousFrameIndex = currentFrameIndex-1; //Get previous frame
    
            // If previous was last frame
            if(previousFrameIndex == -1){
                previousFrameIndex = lastFrameIndex;
            }

            //frame.animateOut(Array.from(frameDiv)[previousFrameIndex][1]);
            Array.from(frameDiv)[previousFrameIndex][1].css("display","none"); //Remove previous frame
            frame.animateIn(Array.from(frameDiv)[currentFrameIndex][1]);

            frame.start();
        }, timing*1000);

    },

    animateIn(element) {
        element.toggle('slide', { direction: "left" }, 1000);
    },
    animateOut(element) {
        element.toggle('slide', { direction: "right" }, 1000);
    }
}