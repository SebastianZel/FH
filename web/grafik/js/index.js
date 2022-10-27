const wrapper = document.querySelector(".wrapper");
const stars = document.querySelectorAll('[data-name^="star"]');
const bigStar = document.querySelector('[data-name="center-star-fill"]');
let counter = 1;
/**
 * Immediately set target-properties
 *
 * documentation: https://greensock.com/docs/v3/GSAP/gsap.set()
 */
gsap.set(bigStar, { transformOrigin: "50% 50%" }); // define animation-center of star

// animate on Wrapper-click
wrapper.addEventListener("click", () => {
  /**
   * Animate a target to another state
   *
   * @param targets - the object(s) whose properties you want to animate.
   * This can be selector text like ".class", "#id", etc. (GSAP uses document.querySelectorAll() internally)
   * or it can be direct references to elements, generic objects, or even an array of objects.
   *
   * @param configuration - an object containing all the properties/values you want to animate, along with any
   * special properties like ease, duration, delay, or onComplete (refer to "Special Properties" in documentation for complete list).
   *
   * documentation: https://greensock.com/docs/v3/GSAP/gsap.to()
   */
   const gsapEffects = [
    { 
      id: "fadeSlideTo",  
      props: { opacity: 0.5, x: 300, yoyo: true, repeat: -1 }
    },
    { 
      id: "fadeSlideFrom", 
      animate: 'from',
      props: { opacity: 0.25, x: -300, yoyo: true, repeat: -1  }
    }
  ];
  
  gsapEffects.forEach(effect => {
    gsap.registerEffect({
      name: effect.id,
      defaults: { duration: 1 },
      extendTimeline: true,
      effect(targets, config) {
        if(counter %2 == 0){
          counter++;
          return gsap.from(targets, {...effect.props,...config })
        } 
        else {
          counter++;
          return gsap.to(targets, {...effect.props,...config })
        }
      }
    });
  });
  
  
  
  let tl = gsap.timeline();
  if(counter %2 == 0){
    tl.fadeSlideTo(".fadeSlideTo")
  }
  else{
    tl.fadeSlideFrom(".fadeSlideFrom", 0)
  }
  



  gsap.to(bigStar, {
    duration: 0.5,
    scale: 1.2,
    yoyo: true,
    repeat: 1,
    ease: "elastic.out(1, 0.3)", // https://greensock.com/docs/v3/Eases
  });

 
});
