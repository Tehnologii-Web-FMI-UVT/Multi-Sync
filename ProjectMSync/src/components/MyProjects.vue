<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <q-card class="my-card">
      <q-card-section class="bg-primary text-white">
        <div class="text-h6">Our Changing Planet</div>
      </q-card-section>

      <q-separator />

      <q-card-actions align="right">
        <q-btn label="Show Dialog1" color="primary" @click="showDialog" />
        <q-btn label="Show Dialog2" color="primary" @click="showDialog" />
      </q-card-actions>
    </q-card>

    <q-card class="my-card">
      <q-card-section class="bg-primary text-white">
        <div class="text-h6">Our Changing Planet</div>
        <div class="text-subtitle2">by John Doe</div>
      </q-card-section>

      <q-separator />

      <q-card-actions align="right">
        <q-btn flat>Action 1</q-btn>
        <q-btn flat>Action 2</q-btn>
      </q-card-actions>
    </q-card>

    <q-card class="my-card">
      <q-card-section class="bg-primary text-white">
        <div class="text-h6">Our Changing Planet</div>
        <div class="text-subtitle2">by John Doe</div>
      </q-card-section>

      <q-separator />

      <q-card-actions align="right">
        <q-btn flat>Action 1</q-btn>
        <q-btn flat>Action 2</q-btn>
      </q-card-actions>
    </q-card>

    <q-card class="my-card">
      <q-card-section class="bg-primary text-white">
        <div class="text-h6">Our Changing Planet</div>
        <div class="text-subtitle2">by John Doe</div>
      </q-card-section>

      <q-separator />

      <q-card-actions align="right">
        <q-btn flat>Action 1</q-btn>
        <q-btn flat>Action 2</q-btn>
      </q-card-actions>
    </q-card>

    <q-card class="my-card">
      <q-card-section class="bg-purple text-white">
        <div class="text-h6">Our Changing Planet</div>
        <div class="text-subtitle2">by John Doe</div>
      </q-card-section>

      <q-card-actions align="around">
        <q-btn flat>Action 1</q-btn>
        <q-btn flat>Action 2</q-btn>
      </q-card-actions>
    </q-card>

    <q-card class="my-card">
      <q-card-section class="bg-teal text-white">
        <div class="text-h6">Our Changing Planet</div>
        <div class="text-subtitle2">by John Doe</div>
      </q-card-section>

      <q-card-actions vertical align="right">
        <q-btn flat>Action 1</q-btn>
        <q-btn flat>Action 2</q-btn>
      </q-card-actions>
    </q-card>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useQuasar } from 'quasar'

export default defineComponent({
  name: 'MyProjects',
  components: {},
  setup () {
    const $q = useQuasar()

    return {
      showDialog () {
        $q.dialog({
        }).onOk(() => {
          // console.log('OK')
        }).onCancel(() => {
          // console.log('Cancel')
        }).onDismiss(() => {
          // console.log('I am triggered on both OK and Cancel')
        })
      }
    }
  }
});
</script>
