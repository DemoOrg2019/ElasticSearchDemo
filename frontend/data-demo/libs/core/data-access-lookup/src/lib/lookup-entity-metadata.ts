import { EntityMetadataMap } from "@ngrx/data";
import { compareCourses } from "./course/model/course";

export const entityMetadata: EntityMetadataMap = {
    Course: {
        sortComparer: compareCourses,
        entityDispatcherOptions: {
            optimisticUpdate: true
        }
    }
};
