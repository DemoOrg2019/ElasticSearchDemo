import { Component } from '@angular/core';

@Component({
  selector: 'data-demo-example-app-entry',
  // template: `<div class="remote-entry">
  //   <h2>example-app's Remote Entry Component</h2>
  //   <router-outlet></router-outlet>
  // </div>`,  
  // styles: [
  //   `
  //     .remote-entry {
  //       background-color: #143055;
  //       color: white;
  //       padding: 5px;
  //     }
  //   `,
  // ],
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss'],
})
export class RemoteEntryComponent {}
