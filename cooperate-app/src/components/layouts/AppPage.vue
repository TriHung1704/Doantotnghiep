<template>
    <div>
        <the-header :className="className"></the-header>
    </div>
    <div class="main">
        <v-main>
            <div class="content">
                <router-view v-slot="slotProps">
                    <transition name="route" mode="out-in">
                        <component :is="slotProps.Component"></component>
                    </transition>
                </router-view>
            </div>
        </v-main>
    </div>
    <div>
        <footer-page></footer-page>
    </div>
</template>
<script>
import TheHeader from "./TheHeader.vue";
import FooterPage from "./FooterPage.vue";
export default {
    components: {
        TheHeader,
        FooterPage
    },
    data() {
        return {
            className: '',
        }
    }
}
</script>
<style scoped>
.main {
    align-items: center;
    justify-content: space-between;
    font-family: "Arial", sans-serif;
}

.main {
    margin: auto;
    width: 92%;
}

.route-enter-from {
    opacity: 0;
    transform: translateY(-5px);
}

.route-leave-to {
    opacity: 0;
    transform: translateY(5px);
}

.route-enter-active {
    transition: all 0.1s ease-out;
}

.route-leave-active {
    transition: all 0.1s ease-in;
}

.route-enter-to,
.route-leave-from {
    opacity: 1;
    transform: translateY(0);
}
</style>