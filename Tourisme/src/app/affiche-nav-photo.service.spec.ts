import { TestBed } from '@angular/core/testing';

import { AfficheNavPhotoService } from './affiche-nav-photo.service';

describe('AfficheNavPhotoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AfficheNavPhotoService = TestBed.get(AfficheNavPhotoService);
    expect(service).toBeTruthy();
  });
});
