// Vue imports
import Vue from 'vue'
import Router from 'vue-router'

// 3rd party imports
import Auth from '@okta/okta-vue'

// our own imports
import Hello from '@/components/Hello'
import VueSample from '@/components/VueSample'

Vue.use(Auth, {
  issuer: 'https://dev-383916.okta.com/oauth2/default',
  client_id: '0oasxuc8twEUPm3SO356',
  redirect_uri: 'http://localhost:8080/implicit/callback',
  scope: 'openid profile email'
})

Vue.use(Router)

let router = new Router({
  mode: 'history',
  routes: [
    {
    path: '/vue-sample',
    name: 'VueSample',
    component: VueSample,
    meta: {
      requiresAuth: true
    }
  },
	{
  	path: '/',
  	name: 'Hello',
  	component: Hello
	},
	{
  	path: '/implicit/callback',
  	component: Auth.handleCallback()
	},
  ]
})

router.beforeEach(Vue.prototype.$auth.authRedirectGuard())

export default router