import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    books: [
      {
        title: "Kafka on the Shore",
        author: "Haruki Murakami",
        read: false,
        isbn: "9781784877989",
        flipped: false
      },
      {
        title: "The Girl With All the Gifts",
        author: "M.R. Carey",
        read: true,
        isbn: "9780356500157",
        flipped: true
      },
      {
        title: "The Old Man and the Sea",
        author: "Ernest Hemingway",
        read: false,
        isbn: "9780684830490",
        flipped: false
      },
      {
        title: "Le Petit Prince",
        author: "Antoine de Saint-Exupéry",
        read: false,
        isbn: "9783125971400",
        flipped: false
      }
    ]
  },
  mutations: {
    TOGGLE_READ_STATUS(state, book){
      book.read = !book.read;
    },
    ADD_NEW_BOOK(state, book){
      state.books.push(book);
    },
    FLIP_CARD(state, book){
      book.flipped = !book.flipped
    }

  },
  actions: {},
  modules: {},
  // Strict should not be used in production code. It is used here as a
  // learning aid to warn you if state is modified without using a mutation.
  strict: true
});
