export enum MDMTable {
    BrandInfo,
    BusinessUnit
}

export interface MDMSearchModel {
    mDMTable : MDMTable,
    id : string,
    code : string,
    name : string,
    dependsOnId : string | undefined
    /*
     public MDMTable MDMTable { get; set; }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? DependOnId { get; set; }
    */
}

export interface MDMSearchModelSource {
    source: MDMSearchModel;
}