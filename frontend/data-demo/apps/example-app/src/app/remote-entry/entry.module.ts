import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { RemoteEntryComponent } from './entry.component';
import { CoursesComponent } from '../components/courses/courses.component';
import { MdmSearchComponent} from '../components/mdm/mdm-search.component'


import { EntityDataModule } from '@ngrx/data';
import { CoreDataAccessLookupModule } from '@data-demo/core/data-access-lookup';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { ElasticsearchService } from '../services/elasticsearch.service';

@NgModule({
  declarations: [
    RemoteEntryComponent, 
    CoursesComponent,
    MdmSearchComponent
  ],
  imports: [
    CommonModule,
    CoreDataAccessLookupModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({
      maxAge: 25, // Retains last 25 states
      //logOnly: environment.production, // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
    }),
    EntityDataModule.forRoot({}),
    RouterModule.forChild([
      {
        path: '',
        component: RemoteEntryComponent,
        children: [
          {
            path: 'courses',
            component: CoursesComponent,
          },
          {
            path: 'search',
            component: MdmSearchComponent,
          },           
        ],
      },
    ]),
  ],
  providers: [ElasticsearchService],
})
export class RemoteEntryModule {}
