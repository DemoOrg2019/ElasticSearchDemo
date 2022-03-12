import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NxWelcomeComponent } from './nx-welcome.component';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { EntityDataModule } from '@ngrx/data';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { CoreDataAccessLookupModule } from '@data-demo/core/data-access-lookup';

@NgModule({
  declarations: [AppComponent, NxWelcomeComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    // CoreDataAccessLookupModule,
    // StoreModule.forRoot({}),
    // EffectsModule.forRoot([]),
    // StoreDevtoolsModule.instrument({
    //   maxAge: 25, // Retains last 25 states
    //   //logOnly: environment.production, // Restrict extension to log-only mode
    //   autoPause: true, // Pauses recording actions and state changes when the extension window is not open
    // }),
    // EntityDataModule.forRoot({}),
    RouterModule.forRoot(
      [
        {
          path: 'example-app',
          loadChildren: () =>
            import('example-app/Module').then((m) => m.RemoteEntryModule),
        },
      ],
      { initialNavigation: 'enabledBlocking' }
    ),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
