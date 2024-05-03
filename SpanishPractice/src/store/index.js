import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    sentences: [
      {
        id: 0,
        sentence: "She wasn't a friend, I was.",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "past",
        verbAAnswer: "era",
        verbBSerOrEstar: "ser",
        verbBPastOrPresent: "past",
        verbBAnswer: "era", 
        fullTranslatedSentence: "Ella no era una amiga, yo lo era."
        }, 
      {
        id: 1,
        sentence: "You(formal) weren't in this place, I was.",
        verbASerOrEstar: "estar",
        verbAPastOrPresent: "past",
        verbAAnswer: "estaba",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "past",
        verbBAnswer: "estaba",
        fullTranslatedSentence: "Usted no estaba en this lugar, yo lo estaba."
      },
      {
        id: 2,
        sentence: "I'm a friend and they are with me.",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "present",
        verbAAnswer: "soy",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "present",
        verbBAnswer: "están",
        fullTranslatedSentence: "Soy una amiga y ellos estan conmigo."
      }, 
      {
        id: 3,
        sentence: "Were you the guy?",
        verbASerOrEstar: "ser",
        verbAPastOrPresent: "past",
        verbAAnswer: "eras",
        fullTranslatedSentence: "¿Eras tú el chico?"
      },
      {
        id:4,
        sentence:"What were you for those people?",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"eras",
        fullTranslatedSentence: "¿Qué eras tú para those people?"      
      },
      {
        id:5,
        sentence:"The boys were my friends.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"eran",
        fullTranslatedSentence: "Los chicos eran mis amigos."      
      },
      {
        id:6,
        sentence:"It was a sock puppet.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"era",
        fullTranslatedSentence: "Era a puppet de sock."      
      },
      {
        id:7,
        sentence:"They were present at 6:00.",
        verbASerOrEstar:"estar",
        verbAPastOrPresent:"past",
        verbAAnswer:"estaban",
        fullTranslatedSentence: "Estaban a 6:00."      
      },
      {
        id:8,
        sentence:"He is here but the girls aren't",
        verbASerOrEstar:"estar",
        verbAPastOrPresent:"present",
        verbAAnswer:"está",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "present",
        verbBAnswer: "están", 
        fullTranslatedSentence: "Él está aquí but las chicas no lo están."      
      },
      {
        id:9,
        sentence:"The house that is my mom's isn't around here.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"present",
        verbAAnswer:"es",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "present",
        verbBAnswer: "está", 
        fullTranslatedSentence: "La casa que es de mi madre no está por aquí."      
      },
      {
        id:10,
        sentence:"I was the tallest(m) when we were in school.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"era",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "past",
        verbBAnswer: "estábamos", 
        fullTranslatedSentence: "Yo era el tallest when estábamos en school."      
      },
      {
        id:11,
        sentence:"The problem was that she wasn't present.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"era",
        verbBSerOrEstar: "estar",
        verbBPastOrPresent: "past",
        verbBAnswer: "estaba",
        fullTranslatedSentence: "The problem era que ella no estaba."      
      },
      {
        id:12,
        sentence:"They were friends(f).",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"eran",
        fullTranslatedSentence: "Eran amigas."      
      },
      {
        id:13,
        sentence:"We are here.",
        verbASerOrEstar:"estar",
        verbAPastOrPresent:"present",
        verbAAnswer:"estamos",
        fullTranslatedSentence: "Estamos aquí."      
      },
      {
        id:14,
        sentence:"We were the girls.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"éramos",
        fullTranslatedSentence: "Éramos las chicas."      
      },
      {
        id:15,
        sentence:"We are not friends(m).",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"present",
        verbAAnswer:"somos",
        fullTranslatedSentence: "No somos amigos."      
      },
      {
        id:16,
        sentence:"I’m at home.",
        verbASerOrEstar:"estar",
        verbAPastOrPresent:"present",
        verbAAnswer:"estoy",
        fullTranslatedSentence: "Estoy en casa."      
      },
      {
        id:17,
        sentence:"They are from Peru.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"present",
        verbAAnswer:"son",
        fullTranslatedSentence: "Son de Perú."      
      },
      {
        id:18,
        sentence:"We were from the same city.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"past",
        verbAAnswer:"éramos",
        fullTranslatedSentence: "Éramos de the same city."      
      },
      {
        id:19,
        sentence:"He was here in order to be my friend.",
        verbASerOrEstar:"estar",
        verbAPastOrPresent:"past",
        verbAAnswer:"estaba",
        fullTranslatedSentence: "Estaba aquí para ser mi amigo."      
      },
      {
        id:20,
        sentence:"You(formal) are not the guy, he is.",
        verbASerOrEstar:"ser",
        verbAPastOrPresent:"present",
        verbAAnswer:"es",
        verbBSerOrEstar: "ser",
        verbBPastOrPresent: "present",
        verbBAnswer: "es",
        fullTranslatedSentence: "Usted no es el chico, él lo es."      
      }
    ]
  },
  getters: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
  }
})
