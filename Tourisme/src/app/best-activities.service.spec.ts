import { TestBed } from '@angular/core/testing';

import { BestActivitiesService } from './best-activities.service';

describe('BestActivitiesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BestActivitiesService = TestBed.get(BestActivitiesService);
    expect(service).toBeTruthy();
  });
});
