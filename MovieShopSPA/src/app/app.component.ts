import { Component } from '@angular/core';
// import{faCalendarAlt} from'@fortawesome/free-solid-svg-icons';

//@Component decorator will make any typescript class into Angular Component
//return 'view'=>templateUrl: './app.component.html',
//excute a component using its selector in any HTML or Component
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MovieShopSPA';
  // faCalendarAlt = faCalendarAlt;
}
