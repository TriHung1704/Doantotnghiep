<template>
    <button v-if="!link" :class="mode + ' ' + col">
      <slot></slot>
    </button>
    <router-link v-else-if="link" :to="to" :class="mode + ' ' + col">
      <slot></slot>
    </router-link>
  </template>
  
  <script>
  export default {
    props: {
      mode: {
        type: String,
        required: false,
        default: null,
      },
      col: {
        type: String,
        required: false,
        default: null,
      },
      link: {
        type: Boolean,
        required: false,
        default: false,
      },
      to: {
        type: String,
        required: false,
        default: "/",
      }
    }
  };
  </script>
  
  <style scoped>
  button,
  a {
    white-space: nowrap;
    text-decoration: none;
    padding: 5px 10px;
    text-align: center;
    font: inherit;
    border: 2px solid #5b5b5b;
    color: #5b5b5b;
    cursor: pointer;
    border-radius: 4px;
    display: inline-block;
  }
  
  a:hover,
  a:active,
  button:hover,
  button:active {
    background-color: #ffffff;
    border-color: #6f6f6f;
    color: #5b5b5b;
  }
  button:disabled,:hover {
    background-color: #8d4437;
    border: 2px solid #8d4437;
  }
  
  .btn-submit {
    background-color: #d34127;
    color: #ffffff;
    border: 2px solid #d34127;
    text-align: center;
  }
  
  .btn-submit:hover,
  .btn-submit:active {
    background-color: #c7503b;
    color: #ffffff;
    border: 2px solid #d34127;
  } 
  .btn-delete {
    border: 2px solid #d34127;
    background-color: #ffffff;
    color: #d34127;
    text-align: center;
  }
  
  .btn-delete:hover,
  .btn-delete:active {
    border: 2px solid #c7503b;
    color: #d87564;
    background-color: #ffffff;
  } 
  </style>