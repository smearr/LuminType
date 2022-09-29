using Godot;
using System;

public class Global : Node
{
	public static int WordsTyped = 0;
	public static Vector2 pos = new Vector2(638, 750);
	public static bool is_dead = false;
	public static bool goingBack = false;
	
public static string[] easy_words = {
"taste","twig","rings","horn","cord","cushion","care","quiet","stage","beam","suit","linen","fairies","snakes","notebook","gold","sidewalk","furniture","haircut","skin","walk","shoe","boats","sofa","pest","flock","show","home","sidewalk","meal","crime","ring","use","color","day","industry","clocks","uncle","sky","polish","battle","trains","snails","friction","iron","pan","sofa","fireman","beginner","order","tooth","friend","branch","cactus","title","touch","help","cattle","scent","stitch","talk","oranges","earth","pet","mask","comparison","key","achiever","need","suggestion","parcel","doctor","memory","sleet","spade","leather","bridge","trouble","circle","fear","toad","needle","apparel","shoes","sneeze","start","mouth","push","string","number","work","rock","tree","father","leather","collar","bed","finger","town","hen","month","wing","bells","opinion","laugh","market","cats","body","kite","ink","boys","fork","egg","fowl","pet","airport","toothbrush","root","learning","man","cap","company","fifth","time","belief","glue","detail","business","bell","pleasure","polish","bushes","mine","grain","glass","top","sea","yoke","bone","fork","beginner","quill","value","value","fog","hook","drink","angle","hospital","juice","rule","chance","bread","use","instrument","exchange","flag","cook","stream","horses","cats","drain","bottle","man","scissors","vein","eye","toy","kitten","idea","hydrant","regret","plot","pen","cows","turn","squirrel","truck","road","baby","sofa","title","smile","balloon","cracker","advice","year","swim","sky","loaf","crime","dogs","orange","ghost","ship","fog","tooth","smoke","carriage","key","book","bucket","bone","achiever","cent","push","drop","bears","rabbits","word","meeting","branch","doll","beetle","middle","flowers","cloud","guide","van","team","foot","grip","pear","range","insect","cemetery","clam","woman","lift","nerve","condition","mitten","impulse","minute","food","children","boats","airplane","copy","wood","shock","attempt","bikes","rat","existence","silver","death","gold","rule","hand","heat","rifle","move","hot","shoes","star","monkey","veil","clover","school","print","stretch","worm","note","soup","bird","notebook","pan","cabbage","brush","club","reason","word","camp","wax","beggar","beggar","jar","trains","disgust","lunch","quill","thing","crush","bushes","sheep","prose","lettuce","horses","rabbits","level","knee","shirt","boundary","month","expansion","church","help","baby","size","chin","whip","bike","guitar","unit","crook","mist","finger","sail","heat","cart","wine","zinc","reward","game","zipper","ear","substance","vessel","zebra","bean","way","way","wave","cow","flame","sheet"
};

public static string[] hard_words = {
"depth", "forgetting", "example", "educate",
"entire", "horizon", "freight", "earliest",
"threat", "relieve", "muscle", "meant",
"exchange", "securing", "obedient", "unsanitary",
"leisure", "crypt", "supervisor", "persuade",
"glamorous", "optimistic", "envious", "controversy",
"deficiency", "schedule", "characteristic",	"environment",
"amusement", "criticize", "venom", "awkward",
"arrangement", "considerable", "barometer", "vulnerable",
"mercenary", "plaintiff", "omitted", "deterrent",
"cameos", "malicious", "obscure", "propeller",
"perceived", "taboo", "technology", "surmise",
"internally", "specific", "protein", "criminal",
"precipitate", "forgery", "unbelievable", "unduly",
"annoyance", "vessel", "insufficient", "capably",
"belligerent", "amnesty", "snobbery", "applicant",
"anxious", "fashionable", "machinery", "laboratory",
"shuddering", "sacrifice", "fibrous", "escalator",
"privilege", "burglary", "melodious", "embargo",
"outrageous", "rectangular", "honorary", "minimize",
"contrary", "passageway", "vertigo", "malady",
"lucrative", "extraordinary", "abstain", "procrastinate",
"serviceable", "parliament", "necessity", "recurrent",
"ominous", "permeate", "religious", "occurred",
"prestigious", "scandalized", "voracious", "universal",
"transient", "meticulous", "personification", "inevitable",
"vigilant", "interrogate", "malignant", "benevolent",
"consequence", "unenforceable", "nostalgia", "omnipotent",
"vivacious", "precocious", "indulgence", "vulnerable",
"vacillate", "inconvenience", "potpourri", "ubiquitous",
"phenomenon", "caricature", "surveillance", "metamorphosis"
};
}
