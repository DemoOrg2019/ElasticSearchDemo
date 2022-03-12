import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseEntityService } from './course/services/course-entity.service';
import { CoursesResolver } from './course/services/courses.resolver';
import { CoursesDataService } from './course/services/courses-data.service';
import { EntityDataModule, EntityDataService, EntityDefinitionService } from '@ngrx/data';
import { entityMetadata } from './lookup-entity-metadata';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    // StoreModule.forFeature(
    //   fromGallery.GALLERY_FEATURE_KEY,
    //   fromGallery.reducer
    // ),
    EffectsModule.forFeature([]),
    EntityDataModule.forRoot({})
  ],
  providers: [
    // CoursesHttpService,
    CourseEntityService,
    CoursesResolver,
    CoursesDataService
]
})
export class CoreDataAccessLookupModule {
  constructor(
    private eds: EntityDefinitionService,
    private entityDataService: EntityDataService,
    private coursesDataService: CoursesDataService) {

    eds.registerMetadataMap(entityMetadata);

    entityDataService.registerService('Course', coursesDataService);

  }
}
