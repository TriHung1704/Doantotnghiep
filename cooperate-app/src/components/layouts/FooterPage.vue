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
      <div class="css-g4muhz">
        <p class="css-11z4vix">Giới thiệu</p>
        <p class="css-128nlh6"><a href="/home">Trang chủ</a></p>
        <p class="css-128nlh6"><a href=" /notification">Tin tức mới nhất</a></p>
        <p class="css-128nlh6"><a href="/recruitment">Tuyển dụng</a></p>
        <p class="css-128nlh6"><a href=" /internship">Thực tập sinh</a></p>
        <p class="css-128nlh6"><a href=" /senimar">Hội thảo công nghệ</a></p>
      </div>
      <div class="css-g4muhz">
        <p class="css-11z4vix">Liên hệ với chúng tôi</p>
        <p class="css-128nlh6">54 Hải Hồ - Thanh Bình - Hải Châu - Đà Nẵng. ĐT: 037325xxxx</p>
        <img class="image-preview" src="https://i.imgur.com/wHTlYgD.png">


      </div>
      <div class="css-g4muhz">
        <p class="css-11z4vix">Thuộc quyền sở hữu</p>
        <p class="css-128nlh6">Thiết kế và sở hữu thuộc : <a href="https://www.tiktok.com/@duongtrihung01">Dương Hùng</a>
        </p>
      </div>

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
.box-footer {
  border-top: #bbb 1px solid;
  padding-top: 5px;
  font-family: "Arial", sans-serif;

}

footer {
  margin-top: 10px;
  height: 350px;
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
  font-family: "Arial", sans-serif;

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

.css-g4muhz {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  width: 33%;

}

.css-11z4vix {
  font-weight: 500;
  color: rgb(255, 255, 255);
  font-size: 16px;
  text-transform: uppercase;
  margin-bottom: 5px;
}

.css-128nlh6 {
  font-size: 14px;
}

a {
  color: azure;
}

img {
  width: 400px;
  height: 150px;
  margin: 10px;
  padding: 10px;
  display: block;
  margin-left: inherit;
}
</style>
