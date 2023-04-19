<template>
    <div>
      <div class="box-card">
        <image-post :image="image" class="card-img-top"></image-post>
        <div class="card-body">
          <router-link :to="detailsLink">{{
            title.length > 30 ? title.substring(0,30) + ' ...' : title
          }}</router-link>
          <div class="card-text" v-html="description.length > 200 ? description.substring(0,200) + ' ...' : description">         
          </div>
        </div>
        <div class="footer-card">
          <div class="row">
            <div class="col-6 text-left">
              <v-icon size="12" icon="mdi-account"></v-icon>
              <p class="display-date">{{ userName }}</p>
            </div>
            <div class="col-6 text-right">
              <p class="text-right display-date">{{ getFormattedDate(createAt) }}</p>
              <v-icon size="12" icon="mdi-calendar"></v-icon>
            </div>
          </div>   
        </div>
      </div>
  </div>
  </template>
  <script>
import moment from 'moment';
  export default {
  props: ["post"],
  data(){
    return{
      id: this.post.id,
      title: this.post.title,
      description: this.post.description,
      image: this.post.image == "" ? "Uploads/Post/thong-bao.jpg" : this.post.image,
      createAt: this.post.createAt,
      userName: this.post.userName
    }
  },
  computed: {
    detailsLink() {
      return `/notification/` + this.id;
    }
  },
  methods: {
    getFormattedDate(date) {
      return moment(date).format("YYYY-MM-DD")
    }
  },
  }
</script>
<style scoped>

.card-text::v-deep h1{
  font-size: 16px;
  text-align: justify;
}
.card-text::v-deep h2{
  font-size: 14px;
  text-align: justify;
}
.card-text::v-deep h3{
  font-size: 12px;
  text-align: justify;
}
.box-card{
  border-radius: 10px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
  margin: 0.5rem auto;
}

.box-card img{
  border-radius: 10px 0px 0px;
  max-height: 150px;
  height: 150px;
  object-fit: cover;
}

.card-body {
  padding: 0px 10px;
  max-height: 150px;
  height: 150px;
}

.card-body a {
  text-decoration: none;
  /* font-size: 16px; */
  font-weight: bold;
  cursor: pointer;
  border-bottom: 2px dashed;
}

.display-date{
  font-size: 10px;
  color: #3a3a3a;
  margin: 0px 0px;
  display: inline-block;
  padding: 5px;
}

.card-body .card-text{
  padding-top: 5px;
  height: 150px;
  font-size: 14px;
  text-align: justify;
}

.footer-card {
  padding: 10px 10px;
  align-items: center;
}

.box-company{
  background-color: darkolivegreen;
  color: aliceblue;
  font-size: 14px;
  text-align: center;
  padding: 5px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}
</style>