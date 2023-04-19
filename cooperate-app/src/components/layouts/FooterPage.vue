<template>
  <footer>
    <ul class="sidenav">
      <li>
        <a href="/">Trường Đại học Sư phạm Kỹ thuật - Đại học Đà Nẵng</a>
      </li>
      <li>
        <a href="/">Hợp tác - Phát triển cùng Doanh nghiệp</a>
      </li>
    </ul>
    <div class="row m-2 text-white box-footer">
      <div class="col-sm-4">Giới thiệu</div>
      <div class="col-sm-4">Liên hệ với chúng tôi</div>
      <div class="col-sm-4">Thuộc quyền sở hữu của ...</div>
    </div>
  </footer>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      
    };
  },
};
</script>
<style scoped>
.box-footer{
  border-top: #bbb 1px solid;
  padding-top: 5px;
}
footer{
  margin-top: 10px;
  height: 200px;
  background-color: #222831;
  /* position: fixed;
  width: -webkit-fill-available;
  z-index: 100;
  bottom: 0; */
}
ul.sidenav {
  list-style-type: none;
  list-style-type: none;
  margin: 0;
  padding: 5px;
  overflow: hidden;
  width: -webkit-fill-available;
}

ul.sidenav li {
  float: left;
  border-right: 1px solid #bbb;
}

ul.sidenav li a {
  font-size: 12px;
  font-weight: bold;
  display: block;
  color: white;
  text-align: center;
  padding: 0px 16px;
  text-decoration: none;
}

ul.sidenav li a i {
  background: rgb(241, 241, 223);
  border-radius: 50%;
}

@media screen and (max-width: 2000px) {
  ul.menunav {
    width: 92%;
    height: auto;
    position: inherit;
    margin: auto;
  }

  ul.menunav li a {
    float: left;
    padding: 15px;
  }

  div.content {
    margin-left: 0;
  }
}

@media screen and (max-width: 400px) {
  ul.menunav li a {
    text-align: center;
    float: none;
  }
}

</style>
