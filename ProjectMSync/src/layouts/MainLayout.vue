<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="toggleLeftDrawer"
        />
        <div>ICON</div>
        <q-toolbar-title> Multi sync </q-toolbar-title>

        <div>
          <q-btn
          v-if="allProjects"
            flat
            dense
            label="My projects"
            color="white"
            @click="toggleAllProjects"
          >
          </q-btn>

          <q-btn
          v-if="!allProjects"
            color="white"
            flat
            dense
            label="All projects"
            style="margin-left: 10px"
            @click="toggleAllProjects"
          >
          </q-btn>
        </div>
        <q-input
          filled
          outlined
          v-model="model"
          label="Search"
          dense
          color="black"
          bold
          bg-color="white"
          :options="search"
          round
          style="width: 250px; margin-left: 15px"
        />
      </q-toolbar>
    </q-header>

    <q-drawer v-model="leftDrawerOpen" show-if-above bordered>
      <q-list>
        <q-item-label header> Nav bar</q-item-label>

        <EssentialLink
          v-for="link in essentialLinks"
          :key="link.title"
          v-bind="link"
        />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view v-if="allProjects" />
      <my-projects v-if="!allProjects" ></my-projects>
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import EssentialLink from 'components/EssentialLink.vue';
import MyProjects from 'components/MyProjects.vue';


const linksList = [
  {
    title: 'Profile',
    caption: 'Username/Password',
    icon: 'people',
    link: '',
  },
  {
    title: 'Github',
    caption: 'github.com/MultiSync',
    icon: 'code',
    link: '',
  },
  {
    title: 'Contact',
    caption: '+40 12321312',
    icon: 'record_voice_over',
    link: '',
  },
  {
    title: 'Networks',
    caption: '@Instagram @Facebook',
    icon: 'public',
    link: '',
  },
  {
    title: 'Learn',
    caption: 'See more',
    icon: 'school',
    link: '',
  },
  {
    title: 'Settings',
    caption: 'Disconnect',
    icon: 'settings',
    link: '',
  },
];

const filters = ['Footbal', 'Date', 'School', 'Shopping', 'Fitness'];
const search = [
  'Footbal team timisoara',
  'Date online',
  'School books',
  'Shopping in town',
  'Fitness gym',
];

export default defineComponent({
  name: 'MainLayout',

  components: {
    EssentialLink,
    MyProjects,
  },

  setup() {
    const leftDrawerOpen = ref(false);
    var allProjects= ref(true);

    return {
      essentialLinks: linksList,
      leftDrawerOpen,
      allProjects,
      model: ref(null),
      modelMultiple: ref(null),
      modelSerach: ref(null),
      search,
      filters,
      toggleLeftDrawer() {
        leftDrawerOpen.value = !leftDrawerOpen.value;
      },
      toggleAllProjects() {
        allProjects.value = !allProjects.value;
      },
    };
  },
});
</script>
